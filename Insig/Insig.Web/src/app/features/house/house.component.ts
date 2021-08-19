import { Component, OnInit } from '@angular/core';
import { ApiHouseService } from '@app/core/services/api-house.service';
import { Observable } from "rxjs";
import { switchMapTo } from "rxjs/operators";
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { DialogueComponent } from './dialogue/dialogue.component';

export interface HouseDto {
  id: number;
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
  emptyHouseSize: number;

  constructor(private _houseService: ApiHouseService, private _snackBar: MatSnackBar, public dialog: MatDialog) { }

  openDialog(house: HouseDto) {
    let dialogRef = this.dialog.open(DialogueComponent);
    let instance = dialogRef.componentInstance;
    instance.oldName = house.name;
    instance.house = house;
    instance.closeDialog.subscribe(() => console.log("fdfd"))
  }

  addHouse(): void {
    const newHouse: HouseDto = {
      id: 0,
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
    this.houseSingleFloor = false;
    this.houseName = '';
    this.houseSize = this.emptyHouseSize;
  }


  deleteHouse(name: string): void {
    const newHouse: HouseDto = {
      name,
      id: 0,
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

  ngOnInit(): void {
    this.houses = this._houseService.getHouseData();
    this.houseName = '';
  }
  addButonDisabled(): boolean {
    if (this.houseName != '' && this.houseSize != null && this.houseSize != undefined) {
      return false;
    }
    return true;
  }
}
