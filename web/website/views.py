from flask import Blueprint, render_template, request, flash, jsonify, abort
from flask_login  import login_required, current_user
from . import db
import json
from .models import User

views = Blueprint('views', __name__)

'''@views.route('/', methods=['GET', 'POST'])
@login_required
def home():
    if request.method == 'POST':
        note = request.form.get('note')

        if len(note) < 1:
            flash('Note is too short.', category = 'error')
        else:
            new_note = Note(data = note, user_id = current_user.id)
            db.session.add(new_note)
            db.session.commit()
            flash('Note saved', category = 'success')

    return render_template('home.html', user = current_user)

@views.route('/delete-note', methods=['POST'])
def delete_note():
    note = json.loads(request.data)
    noteId = note['noteId']
    note = Note.query.get(noteId)
    if note:
        if note.user_id == current_user.id:
            db.session.delete(note)
            db.session.commit()
    
    return jsonify({})'''

@views.route('/my-students')
@login_required
def my_students():
    students = User.query.filter(User.is_teacher != True).all()
    columns = ['full_name', 'email', 'password', 'final_grade']
    return render_template('my_students.html', user = current_user, students = students, columns = columns)

@views.route('/assignments')
@login_required
def assignments():
    return render_template('assignments.html', user = current_user)

@views.route('/my-grades/<int:student_id>')
@login_required
def my_grades(student_id):
    students = User.query.filter(User.is_teacher != True).all()
    columns = ['full_name', 'email', 'password', 'final_grade', 'assignments']
    return render_template('my_grades.html', user=current_user, id = student_id, columns = columns, students = students)

@views.route('/assignment-1')
@login_required
def assignment_1():
    return render_template('assignment_1.html', user = current_user)

@views.route('/assignment-2')
@login_required
def assignment_2():
    return render_template('assignment_2.html', user = current_user)

