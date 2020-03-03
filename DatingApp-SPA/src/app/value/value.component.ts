import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {

   values: any; // any means it is an ordinary javascript variable...doesn't have any type safety. etc.

  constructor(private http: HttpClient) { }

  ngOnInit() {

    this.getValues();

  }

  getValues() {

    // normally we would not insert a string of the http.
    this.http.get('http://localhost:5000/api/values').subscribe(
      response => {this.values = response; },
      error => {console.log(error);
      });

  }

}
