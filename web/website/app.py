from flask import Flask, render_template, request, session, redirect, url_for
from firebase_admin import credentials, firestore
from google.cloud.firestore_v1.base_query import FieldFilter
import uuid
import firebase_admin
import firebase
import json

#Init flask app
app = Flask(__name__)
app.secret_key = 'your_secret_key'  # Change this to a secure secret key

#Init Firestore
cred = credentials.Certificate('website\keys\key_app.json')
firestore_app = firebase_admin.initialize_app(cred)
# init firestore storage
db = firestore.client()




firebaseConfig = {
    "apiKey": "AIzaSyAmj6G_f76OML28LDaBpLPgXFcivxHAWLA",
    "authDomain": "pigvr-d43d5.firebaseapp.com",
    "databaseURL": "https://pigvr-d43d5-default-rtdb.firebaseio.com",
    "projectId": "pigvr-d43d5",
    "storageBucket": "pigvr-d43d5.appspot.com",
    "messagingSenderId": "200880306592",
    "appId": "1:200880306592:web:255d538e6d45e33c82ccc5",
    "measurementId": "G-D1CHZNNBMY"
  };
#Init firebase webapp

fire_app = firebase.initialize_app(firebaseConfig)
# init firestore auth
auth = fire_app.auth()

def get_status(id):
    """Get status of the current user"""
    docs = db.collection("users").stream()
    for user in docs:
        user_dict = user.to_dict()
        if user_dict["local_id"] == id:
            return user_dict["is_teacher"] 
    return False
def get_teacher_classes(id):
    """Get all classes a teacher owns"""
    docs = db.collection("classrooms").stream()
    class_arr = []
    for classroom in docs:
        class_dict  = classroom.to_dict()
        if class_dict["ownerId"] == id:
            class_arr.append(class_dict["class_code"])
    return class_arr
def get_student_classes( id, email):
    """Get all classes a student is a part of"""
    print("student classes")
    
    results =  db.collection("classrooms").where(filter=FieldFilter("students", "array_contains", {"id": id ,"email"  : email})).stream()
    enrolled_classes = []
    for doc in results:
        class_dict = doc.to_dict()
        enrolled_classes.append(class_dict["class_code"]) 
    return enrolled_classes
def join_class(id, email, class_code):
    """Given a student profile, and class code enter the student into a class """
    print("joining class")
    classes_ref = db.collection("classrooms")

    query = classes_ref.where("class_code", "==", class_code).limit(1)
    results = query.stream()
    student_data = {"id": id, "email" : email}
    for doc in results:
        class_ref = doc.reference
        class_ref.update({"students": firestore.ArrayUnion([student_data])})
        return 200
    return  401
def get_class_info(class_code , isTeacher):
    classes_ref = db.collection("classrooms")

    query = classes_ref.where("class_code", "==", class_code).limit(1)
    docs = query.stream()
    for doc in docs:
        class_data = doc.to_dict()
        if is_teacher:
            return class_data
        else:
            studnts = class_data
        
    return 401

@app.route('/')
def landing_page():
    return render_template('landing_page.html')


@app.route('/login', methods=['GET', 'POST'])
def login():
    try:
        if request.method == 'POST':
            username = request.form.get('username')
            password = request.form.get('password')
            user = auth.sign_in_with_email_and_password(username, password)
            print("logged in user ", user)
            session["user"] = user
            local_id = user['localId']
            session['is_teacher'] = get_status(local_id)
            session["token"] = user["idToken"]
            return redirect('dashboard')
    except Exception as e:
        error_args = e.args[1]
        error_packet = json.loads(error_args)
        print(error_packet)
        error_msg = error_packet["error"]["message"]
        return render_template('login.html' ,error = error_msg)
    return render_template('login.html')

@app.route('/register', methods=['GET', 'POST'])
def register():
    if request.method == 'POST':
        try:
            print('register post')
            # Check username and password (dummy authentication for demonstration)
            username = request.form.get('username')
            password = request.form.get('password')
            is_teacher = True if request.form.get('isTeacher') else False
            user = auth.create_user_with_email_and_password(username, password)
            localId =  user["localId"]
            session["user"] = user
            session["is_teacher"] = is_teacher
            session["token"] = user["idToken"]
            newUser = {
                "local_id" : localId,
                "email" : username,
                "is_teacher" : is_teacher
            }
            db.collection('users').add(newUser)
            return redirect('dashboard')
        except Exception as e:
            error_args = e.args[1]
            error_packet = json.loads(error_args)
            print(error_packet)
            error_msg = error_packet["error"]["message"]
            return render_template('register.html' ,error = error_msg)
    return render_template('register.html')

@app.route('/logout')
def log_out():
    session["user"] = None
    return redirect(url_for('landing_page'))
@app.route('/information')
def information():
    return render_template('information.html')


@app.route('/dashboard' , methods = ["GET"])
def dashboard_get():
    data  = {}
    try:
        id_token = session["token"]
        decoded_token = auth.verify_id_token(id_token)
        is_teacher = session["is_teacher"]
        class_data = []
        if is_teacher:
            class_data = get_teacher_classes(decoded_token["user_id"])
        else:
            class_data = get_student_classes(decoded_token["user_id"],decoded_token["email"])
            print("student class data ", class_data)
        data = {
            'email': decoded_token['email'],
            'role' : "Teacher" if is_teacher else "Student"
        }
    except Exception as e:
        print(e)
        return redirect(url_for('login'))
    return render_template('dashboard.html', data=data, class_data=class_data, post_message = session.pop('message', None))

@app.post('/dashboard')
def create_or_join_classroom():
    """Add a classroom Document, each student joining is a collection which has 2 documents,
      assignment 1 and assignment 2. Assignment 1 and 2 both have field for completion"""
    print("request type ", request.form["type"])
    if request.form["type"] == "add_class":
        #code for a teahcer to create  a class
        if session["is_teacher"] == True:
            id = session["user"]["localId"]
            email = session["user"]["email"]
            is_teacher = get_status(id)
            class_code = str(uuid.uuid4())[:7]
            classroom = {
                "ownerId" : id,
                "ownerEmail" : email,
                "class_code" : class_code,
                "students" : []
            }
            db.collection('classrooms').add(classroom)
    elif request.form['type'] == "join_class":
        #code for a student to join a class
        class_code = request.form["class_code"]
        email = session["user"]["email"]
        student_id = session["user"]["localId"]
        join_request = join_class(student_id,email,class_code)
        if join_request == 401:
            session["message"] = "Invlaid Class"
    return redirect(url_for('dashboard_get'))

@app.route('/redirect/<string:class_code>')
def redirect_to_class(class_code):
    return redirect(url_for('classroom' , class_code=class_code))

@app.route('/classroom/<string:class_code>')
def classroom(class_code):
    return render_template('classroom_teacher.html' ,class_code=class_code )

@app.route('/pig-part-1')
def pig_part_1():
    return render_template('pig_part_1.html', dissection_info=dissection_info_part1)


@app.route('/pig-part-2')
def pig_part_2():
    return render_template('pig_part_2.html', dissection_info=dissection_info_part2)

def is_teacher(local_id):
    """Searches data base for user and returns teacher status"""
   
# Run the Flask app
if __name__ == '__main__':
    app.run(debug=True)