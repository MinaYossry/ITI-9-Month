import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Day3Task';
  StudentsList: { name: string; age: string }[] = [];

  GetData(data: { name: string; age: string }) {
    this.StudentsList.push(data);
  }
}
