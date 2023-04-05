import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { RegisterationComponent } from './Components/registeration/registeration.component';
import { StudentsListComponent } from './Components/students-list/students-list.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [AppComponent, RegisterationComponent, StudentsListComponent],
  imports: [BrowserModule, FormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
