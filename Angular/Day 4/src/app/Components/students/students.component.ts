import { Component } from '@angular/core';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css'],
})
export class StudentsComponent {
  StudentsList: {
    id: number;
    FirstName: string;
    LastName: string;
    age: number;
  }[] = [
    { id: 1, FirstName: 'Mina', LastName: 'Yossry', age: 25 },
    { id: 2, FirstName: 'Mina', LastName: 'Yossry', age: 25 },
    { id: 3, FirstName: 'Mina', LastName: 'Yossry', age: 25 },
    { id: 4, FirstName: 'Mina', LastName: 'Yossry', age: 25 },
    { id: 5, FirstName: 'Mina', LastName: 'Yossry', age: 25 },
    { id: 6, FirstName: 'Mina', LastName: 'Yossry', age: 25 },
    { id: 7, FirstName: 'Mina', LastName: 'Yossry', age: 25 },
    { id: 8, FirstName: 'Mina', LastName: 'Yossry', age: 25 },
    { id: 9, FirstName: 'Mina', LastName: 'Yossry', age: 25 },
  ];
}
