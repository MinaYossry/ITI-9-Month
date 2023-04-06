import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentsService } from 'src/app/Services/students.service';

@Component({
  selector: 'app-confirm-delete',
  templateUrl: './confirm-delete.component.html',
  styleUrls: ['./confirm-delete.component.css'],
})
export class ConfirmDeleteComponent {
  constructor(
    private readonly StudentService: StudentsService,
    private readonly Activate: ActivatedRoute,
    private readonly route: Router
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

  Delete() {
    if (this.SelectedStudent) {
      this.StudentService.deleteStudentById(this.SelectedStudent.id).subscribe({
        next: () => {
          this.route.navigate(['/']);
        },
        error: (error) => {
          console.log(error);
        },
      });
    }
  }
}
