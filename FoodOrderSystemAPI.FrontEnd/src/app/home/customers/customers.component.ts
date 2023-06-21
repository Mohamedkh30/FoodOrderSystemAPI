import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthentcationService } from 'src/app/services/authentcation.service';
import CustomerToRead from 'src/app/types/CustomerToReadOfServer';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent  implements OnInit {

  Customers: CustomerToRead[] = []; 
  constructor(private authservice: AuthentcationService , private httpClient :HttpClient) { }

  ngOnInit(): void {
   this.httpClient.get<CustomerToRead[]>("https://localhost:7020/api/Customer").subscribe((CusotmersData) => {
     this.Customers = CusotmersData;
      })
  }
}
