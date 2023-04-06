import { Component, OnInit } from '@angular/core';
import { StudentsService } from 'src/app/Services/students.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css'],
})
export class StudentsComponent implements OnInit {
  constructor(private readonly StudentService: StudentsService) {}

  StudentList: any;
  ngOnInit(): void {
    this.StudentService.getAllStudents().subscribe({
      next: (data) => {
        this.StudentList = data;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
}
