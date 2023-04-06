import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './Components/header/header.component';
import { StudentsComponent } from './Components/students/students.component';
import { DetailsComponent } from './Components/details/details.component';
import { ErrorComponent } from './Components/error/error.component';
import { StudentFormComponent } from './Components/student-form/student-form.component';
import { HttpClientModule } from '@angular/common/http';
import { StudentsService } from './Services/students.service';
import { ConfirmDeleteComponent } from './Components/confirm-delete/confirm-delete.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    StudentsComponent,
    DetailsComponent,
    ErrorComponent,
    StudentFormComponent,
    ConfirmDeleteComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [StudentsService],
  bootstrap: [AppComponent],
})
export class AppModule {}
