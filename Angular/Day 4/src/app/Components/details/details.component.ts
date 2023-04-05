import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
})
export class DetailsComponent {
  Student: {
    id: number;
    FirstName: string;
    LastName: string;
    age: number;
  } = { id: 5, FirstName: 'Mina', LastName: 'Yossry', age: 25 };

  constructor(Activate: ActivatedRoute) {
    this.Student.id = Activate.snapshot.params['id'];
  }
}
