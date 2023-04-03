import { Component } from '@angular/core';

@Component({
  selector: 'app-binded-input',
  templateUrl: './binded-input.component.html',
  styleUrls: ['./binded-input.component.css'],
})
export class BindedInputComponent {
  Username = '';
  Reset() {
    this.Username = '';
  }
}
