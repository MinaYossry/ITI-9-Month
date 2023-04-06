import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentsComponent } from './Components/students/students.component';
import { DetailsComponent } from './Components/details/details.component';
import { ErrorComponent } from './Components/error/error.component';
import { StudentFormComponent } from './Components/student-form/student-form.component';
import { ConfirmDeleteComponent } from './Components/confirm-delete/confirm-delete.component';

const routes: Routes = [
  { path: '', component: StudentsComponent },
  { path: 'students', component: StudentsComponent },
  { path: 'students/:id', component: DetailsComponent },
  { path: 'insertStudent', component: StudentFormComponent },
  { path: 'students/edit/:id', component: StudentFormComponent },
  { path: 'students/delete/:id', component: ConfirmDeleteComponent },
  { path: '**', component: ErrorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
