import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StudentsService } from 'src/app/Services/students.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
})
export class DetailsComponent implements OnInit {
  constructor(
    private readonly StudentService: StudentsService,
    private readonly Activate: ActivatedRoute
  ) {}

  SelectedStudent: any = null;

  ngOnInit(): void {
    let StudentId = this.Activate.snapshot.params['id'];
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
