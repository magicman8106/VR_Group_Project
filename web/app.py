from flask import Flask, render_template, request, session, redirect, url_for

app = Flask(__name__)
app.secret_key = 'your_secret_key'  # Change this to a secure secret key


# Dummy data for demonstration purposes
students = [
    {'name': 'Student 1', 'assignment1': 'Completed', 'assignment2': 'Not completed'},
    {'name': 'Student 2', 'assignment1': 'Not completed', 'assignment2': 'Completed'},
    # Add more student data as needed
]

dissection_info_part1 = """
Lorem ipsum dolor sit amet, consectetur adipiscing elit.
"""

dissection_info_part2 = """
Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
"""


# Routes for login, dashboard, pig dissection, and grades pages

@app.route('/')
def landing_page():
    return render_template('landing_page.html')


@app.route('/login', methods=['GET', 'POST'])
def login():
    if request.method == 'POST':
        # Check username and password (dummy authentication for demonstration)
        username = request.form.get('username')
        password = request.form.get('password')
        if username == 'teacher' and password == 'password':
            session['role'] = 'teacher'
            return redirect(url_for('dashboard'))
        elif username == 'student' and password == 'password':
            session['role'] = 'student'
            return redirect(url_for('dashboard'))
        else:
            return render_template('login.html', error='Invalid username or password')
    return render_template('login.html')

@app.route('/register')
def register():
    return render_template('register.html')
@app.route('/dashboard')
def dashboard():
    if 'role' not in session:
        return redirect(url_for('login'))

    if session['role'] == 'teacher':
        return render_template('dashboard_teacher.html', students=students)
    else:
        return render_template('dashboard_student.html', students=students)


@app.route('/pig-part-1')
def pig_part_1():
    return render_template('pig_part_1.html', dissection_info=dissection_info_part1)


@app.route('/pig-part-2')
def pig_part_2():
    return render_template('pig_part_2.html', dissection_info=dissection_info_part2)


# Run the Flask app
if __name__ == '__main__':
    app.run(debug=True)
