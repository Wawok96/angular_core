import { Component, OnInit } from '@angular/core';
import { ApiHouseService } from '@app/core/services/api-house.service';
import { Observable } from "rxjs";
import { switchMapTo } from "rxjs/operators";
import { MatSnackBar } from '@angular/material/snack-bar';

export interface HouseDto {
  name: string;
  sizeInMeters: number;
  singleFloor: boolean;
}

@Component({
  selector: 'app-house',
  templateUrl: './house.component.html',
  styleUrls: ['./house.component.scss']
})
export class HouseComponent implements OnInit {
  houses!: Observable<HouseDto[]>;
  houseName: string;
  houseSize: number;
  houseSingleFloor: boolean;

  constructor(private _houseService: ApiHouseService, private _snackBar: MatSnackBar) { }

  addHouse(): void {
    const newHouse: HouseDto = {
      name: this.houseName,
      sizeInMeters: this.houseSize,
      singleFloor: this.houseSingleFloor
    }
    this.houses = this._houseService.addHouseData(newHouse)
      .pipe(
        switchMapTo(this._houseService.getHouseData())
      );
    this._snackBar.open(newHouse.name + " added to your houses!", "close", {
      duration: 5000
    })
  }


  deleteHouse(name: string): void {
    const newHouse: HouseDto = {
      name,
      sizeInMeters: 0,
      singleFloor: false
    }
    this.houses = this._houseService.deleteHouseData(newHouse)
      .pipe(
        switchMapTo(this._houseService.getHouseData())
      );
    this._snackBar.open(newHouse.name + " removed to your houses!", "close", {
      duration: 5000
    })
  }


  isFieldsFilled(): boolean {
    if (this.houseName.length > 0 && this.houseSize) {
      return true;
    }
    return false;
  }

  ngOnInit(): void {
    this.houses = this._houseService.getHouseData();
  }
}
