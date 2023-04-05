import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.css'],
})
export class StudentsListComponent {
  @Input() Students: { name: string; age: string }[] = [];
}
