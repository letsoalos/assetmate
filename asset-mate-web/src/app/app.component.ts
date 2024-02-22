import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Vehicle } from './models/vehicle';
import { Pagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Asset Mate';
  vehicles: Vehicle[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<Pagination<Vehicle[]>>('https://localhost:5001/api/Fleet/get-vehicles?pageSize=50').subscribe({
      next: response => this.vehicles = response.data,
      error: error => console.log(error),
      complete: () => {
        console.log('request completed');
        console.log('extra statement');
      }
    })
  }


}
