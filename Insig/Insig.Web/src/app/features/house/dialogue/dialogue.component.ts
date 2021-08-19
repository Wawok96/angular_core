import { Component, Input } from '@angular/core';
import { HouseDto } from '../house.component';
import { Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-dialogue',
  templateUrl: './dialogue.component.html',
  styleUrls: ['./dialogue.component.scss']
})
export class DialogueComponent {
  @Input() oldName: string;
  @Input() house: HouseDto;
  @Output() closeDialog = new EventEmitter<void>();

  close() {
    this.closeDialog.emit();
  }
  save() {
    this.closeDialog.emit();

  }
}
