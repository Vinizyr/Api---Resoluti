import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-valid-msg',
  templateUrl: './valid-msg.component.html',
  styleUrls: ['./valid-msg.component.css']
})
export class ValidMsgComponent implements OnInit {

  @Input() control: AbstractControl
  text: string;



  hasErro(): boolean {

    //console.log(this.control)
    if (this.control?.hasError('required') && this.control.touched) {
      console.log(this.control?.hasError)
      this.text = `Campo necessário.`;
      return true;
    }

    if (this.control?.hasError('minlength') && this.control.touched) {
      this.text = `Tamanho mínimo: ${this.control.errors?.['minlength'].requiredLength} caracteres.`;
      console.log(this.control?.hasError('minlength'))
      //console.log(this.text)
      return true;
    }

    if (this.control?.hasError('maxlength') && this.control.touched) {
      this.text = `Tamanho máximo: ${this.control.errors?.['maxlength'].requiredLength} caracteres.`;
      console.log(this.control?.hasError('maxlength'))
      //console.log(this.text)
      return true;
    }

    if (this.control?.hasError('pattern') && this.control.touched) {
      this.text = `Formato inválido`;
      console.log(this.control?.hasError('pattern'))
      //console.log(this.text)
      return true;
    }

    return false;
  }
  constructor() { }

  ngOnInit(): void {
  }

}
