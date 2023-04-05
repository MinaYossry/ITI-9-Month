import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-registeration',
  templateUrl: './registeration.component.html',
  styleUrls: ['./registeration.component.css'],
})
export class RegisterationComponent {
  name: string = '';
  age: string = '';

  @Output() InsertStudent = new EventEmitter();

  get IsNameValid() {
    return this.name.length >= 3;
  }

  get IsAgeValid() {
    return +this.age > 20 && +this.age < 40;
  }

  Add() {
    if (this.IsNameValid && this.IsAgeValid) {
      this.InsertStudent.emit({ name: this.name, age: this.age });
    }
  }
}
