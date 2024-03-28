from . import db
from flask_login import UserMixin
from sqlalchemy.sql import funcfilter
from sqlalchemy import event
from random import randrange

'''class Note(db.Model):
    id = db.Column(db.Integer, primary_key = True)
    data = db.Column(db.String(10000))
    date = db.Column(db.DateTime(timezone = True), default = func.now())
    user_id = db.Column(db.Integer, db.ForeignKey('user.id'))

class User(db.Model, UserMixin):
    id = db.Column(db.Integer, primary_key = True)
    email = db.Column(db.String(150), unique = True)
    password = db.Column(db.String(150))
    first_name = db.Column(db.String(150))
    notes = db.relationship('Note')'''

'''user_assignment = db.Table(
    "user_assignment",
    db.Column("user_id", db.Integer, db.ForeignKey("user.id")),
    db.Column("assignment_id", db.Integer, db.ForeignKey("assignment.id")),
)'''

class Assignment(db.Model):
    #__tablename__ = "assignment"
    id = db.Column(db.Integer, primary_key = True)
    name = db.Column(db.String(150))
    total_grade = db.Column(db.Integer, default=0)
    module_1_grade = db.Column(db.Integer, default=0)
    module_2_grade = db.Column(db.Integer, default=0)
    #users = db.relationship('User', secondary = user_assignment, back_populates = 'assignments')
    user_id = db.Column(db.Integer, db.ForeignKey('user.id'))

class User(db.Model, UserMixin):
    #__tablename__ = "user"
    id = db.Column(db.Integer, primary_key = True)
    email = db.Column(db.String(150), unique = True)
    password = db.Column(db.String(150))
    full_name = db.Column(db.String(150))
    is_teacher = db.Column(db.Boolean, default=False)
    #assignments = db.relationship('Assignment', secondary = user_assignment, back_populates = 'users')
    final_grade = db.Column(db.String(1), default='-')
    assignments = db.relationship('Assignment')

@event.listens_for(User.__table__, 'after_create')
def populate_users(*args, **kwargs):
    teacher = User(email='teacher@gmail.com', password='admin', full_name='Dumble Dore', is_teacher=True)
    print('teacher added supposedly Inshallah')
    db.session.add(teacher)

    student1 = User(email='student1@gmail.com', password='student1', full_name='Billy Boy', is_teacher=False)
    db.session.add(student1)

    student2 = User(email='student2@gmail.com', password='student2', full_name='Harry Potter', is_teacher=False)
    db.session.add(student2)

    student3 = User(email='student3@gmail.com', password='student3', full_name='Her Mione', is_teacher=False)
    db.session.add(student3)

    db.session.commit()

@event.listens_for(Assignment.__table__, 'after_create')
def create_assignments(*args, **kwargs):

    students = User.query.all()
    for student in students:
        assignment1 = Assignment(name='Pig Dissection Activity 1', total_grade = randrange(100), user_id = student.id)
        db.session.add(assignment1)

        assignment2 = Assignment(name='Pig Dissection Activity 2', total_grade = randrange(100), user_id = student.id)
        db.session.add(assignment2)

    db.session.commit()
    
'''class Student(db.model, UserMixin):
    id = db.Column(db.Integer, primary_key = True)
    email = db.Column(db.String(150), unique = True)
    password = db.Column(db.String(150))
    full_name = db.Column(db.String(150))
    assignments = db.relationship('Assignment')

class Teacher(db.model, UserMixin):
    id = db.Column(db.Integer, primary_key = True)
    email = db.Column(db.String(150), unique = True)
    password = db.Column(db.String(150))
    full_name = db.Column(db.String(150))
    students = db.relationship('Student')
'''





