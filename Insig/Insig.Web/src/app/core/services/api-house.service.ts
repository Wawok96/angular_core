import { Injectable } from '@angular/core';
import { ApiClientService } from "./api-client.service";
import { Observable } from "rxjs";
import { HouseDto } from '@app/features/house/house.component';
import { stringify } from '@angular/compiler/src/util';

@Injectable({
  providedIn: 'root'
})
export class ApiHouseService {

  constructor(private _apiClientService: ApiClientService) { }

  getHouseData(): Observable<HouseDto[]> {
    return this._apiClientService.get(`${appConfig.apiUrl}/house/houses`);
  }

  addHouseData(house: HouseDto): Observable<HouseDto> {
    return this._apiClientService.post(`${appConfig.apiUrl}/house/houses`, { data: house });
  }
  deleteHouseData(house: HouseDto): Observable<HouseDto> {
    return this._apiClientService.patch(`${appConfig.apiUrl}/house/houses`, { data: house });
  }
}

