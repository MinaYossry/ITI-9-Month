import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  formValidation = new FormGroup({
    Name: new FormControl(null, [Validators.required, Validators.minLength(3)]),
    Age: new FormControl(null, [
      Validators.required,
      Validators.min(20),
      Validators.max(40),
    ]),
    Email: new FormControl(null, [
      Validators.required,
      Validators.email,
      Validators.pattern(/^[^\s@]+@[^\s@]+\.[^\s@]+$/),
    ]),
  });

  get IsValidName() {
    return (
      !this.formValidation.controls.Name.value ||
      this.formValidation.controls.Name.valid
    );
  }

  get IsValidAge() {
    return (
      !this.formValidation.controls.Age.value ||
      this.formValidation.controls.Age.valid
    );
  }

  get IsvalidEmail() {
    return (
      !this.formValidation.controls.Email.value ||
      this.formValidation.controls.Email.valid
    );
  }

  SubmitForm() {
    if (this.formValidation.valid) {
      alert('Data is valid');
    } else {
      alert('Data is not valid');
    }
  }
}
