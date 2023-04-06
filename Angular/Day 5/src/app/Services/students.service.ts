import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class StudentsService {
  constructor(private readonly Client: HttpClient) {}

  private readonly URL = 'http://localhost:3000/students';

  getAllStudents() {
    return this.Client.get(this.URL);
  }

  getStudentById(id: number) {
    return this.Client.get(`${this.URL}/${id}`);
  }

  insertStudent(student: any) {
    return this.Client.post(this.URL, student);
  }
  updateStudentById(id: number, student: any) {
    return this.Client.put(`${this.URL}/${id}`, student);
  }

  deleteStudentById(id: number) {
    return this.Client.delete(`${this.URL}/${id}`);
  }
}
