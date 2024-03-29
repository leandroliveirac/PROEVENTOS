import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {
  @Input() titulo: string = '';
  @Input() iconClass: string = 'fa fa-user';
  @Input() subtitulo: string = 'Desde 2021';
  @Input() botaoListar: boolean = false;

  constructor(private router: Router) { }

  ngOnInit() {
  }

  Listar() : void{
    this.router.navigate([`/${this.titulo.toLocaleLowerCase()}/lista`]);
  }

}
