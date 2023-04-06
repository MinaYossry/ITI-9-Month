import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentsService } from 'src/app/Services/students.service';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.css'],
})
export class StudentFormComponent implements OnInit {
  constructor(
    private readonly StudentService: StudentsService,
    private readonly Activate: ActivatedRoute,
    private readonly route: Router
  ) {}

  SelectedStudent: any = {
    id: null,
    name: null,
    age: null,
    email: null,
    phone: null,
    courses: null,
  };

  ngOnInit(): void {
    let StudentId = this.Activate.snapshot.params['id'];
    if (StudentId) {
      this.StudentService.getStudentById(StudentId).subscribe({
        next: (data) => {
          this.SelectedStudent = data;
        },
        error: (error) => {
          console.log(error);
        },
      });
    }
  }

  onSubmit() {
    if (this.SelectedStudent.id) {
      this.StudentService.updateStudentById(
        this.SelectedStudent.id,
        this.SelectedStudent
      ).subscribe({
        next: (data) => {
          this.route.navigate(['/']);
        },
        error: (error) => {
          console.log(error);
        },
      });
    } else {
      this.StudentService.insertStudent(this.SelectedStudent).subscribe({
        next: (data) => {
          this.route.navigate(['/']);
        },
        error: (error) => {
          console.log(error);
        },
      });
    }
  }
}
