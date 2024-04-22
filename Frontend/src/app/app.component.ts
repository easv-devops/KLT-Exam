import {Component, OnInit} from '@angular/core';
import {addressModel, ResponseDto} from "./models";
import {environment} from "../environments/environment";
import {HttpClient} from "@angular/common/http";
import {firstValueFrom} from "rxjs";

@Component({
  selector: 'app-root',
  template: `


    <ion-content>
      <ion-header>Address Book</ion-header>

      <ion-row>
        <ion-col size="1">
          Name
        </ion-col>
        <ion-col>

          <input id="input1" [(ngModel)]="value1">
        </ion-col>

      </ion-row>
      <ion-row>
        <ion-col size="1">
          Address
        </ion-col>
        <ion-col>
          <input id="input2" [(ngModel)]="value2">
        </ion-col>
      </ion-row>
      <ion-row>

        <ion-col size="1">

          Zip
        </ion-col>

        <ion-col size="2.3">

          <input id="input3" [(ngModel)]="value3">

        </ion-col>
        <ion-col size="0.8">

          City

        </ion-col>
        <ion-col>

          <input id="input3" [(ngModel)]="value4">

        </ion-col>
      </ion-row>
      <ion-row>

        <button id="button1" (click)="saveAddress()">Save Address</button>


      </ion-row>

      <h1 id="h1-1">Saved name is: {{ Succes }}</h1>


      <p id="h1-2">version: {{ version }}</p>


      <ion-row>

        <h1>Addresses</h1>

      </ion-row>
      <ion-row>
        <ion-col style=" border: 2px solid #000;">
          <h1>Name</h1>
        </ion-col>

        <ion-col style=" border: 2px solid #000;">
          <h1>Address</h1>
        </ion-col>

        <ion-col style=" border: 2px solid #000;">
          <h1>Zip</h1>
        </ion-col>

        <ion-col style=" border: 2px solid #000;">
          <h1>City</h1>
        </ion-col>


      </ion-row>


      <div *ngFor="let his of addresses">


        <ion-row>
          <ion-col style=" border: 2px solid #000;">
            <h1>{{ his.name }}</h1>
          </ion-col>

          <ion-col style=" border: 2px solid #000;">
            <h1>{{ his.streetnameAndNumber }}</h1>
          </ion-col>

          <ion-col style=" border: 2px solid #000;">
            <h1>{{ his.zip }}</h1>
          </ion-col>

          <ion-col style=" border: 2px solid #000;">
            <h1>{{ his.city }}</h1>
          </ion-col>


        </ion-row>


      </div>


    </ion-content>



  `,
  styleUrls: ['app.component.scss'],
})
export class AppComponent implements  OnInit{

  value1: string="";
  value2: string="";
  value3: string="";
  value4: string="";
  Succes: string="";
  addresses: addressModel[]=[];
  version:number=0;

  constructor(private readonly http: HttpClient) {}

  async saveAddress() {



    let addressModel: addressModel = {
      name: this.value1,
      streetnameAndNumber:this.value2,
      zip: this.value3,
      city: this.value4

    }

    var req = this.http.post<ResponseDto<addressModel>>(environment.baseUrl+'/address/post',
      addressModel);
    var response =await firstValueFrom<ResponseDto<addressModel>>(req);


    addressModel=response.responseData;
    this.Succes=addressModel.name;
    this.getAddresses();

  }




  async getAddresses()
  {
    var result= await firstValueFrom(this.http.get<ResponseDto<addressModel[]>>(environment.baseUrl+ "/address/get"))
    this.addresses=result.responseData;

    console.log(result.responseData);
  }


  async getVersion()
  {
    var result= await firstValueFrom(this.http.get<ResponseDto<number>>(environment.baseUrl+ "/address/getVersion"))
    this.version=result.responseData;


  }



  ngOnInit(): void {
    this.getAddresses();
    this.getVersion();
  }



}
