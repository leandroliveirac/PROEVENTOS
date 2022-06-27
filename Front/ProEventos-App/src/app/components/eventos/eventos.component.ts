import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from '../../models/Evento';
import { EventoService } from '../../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  modalRef?: BsModalRef;
  public eventos: any = [];
  private _eventos: any = [];
  public larguraImg = 150;
  public margemImg = 2;
  public exibirImg: boolean = true;
  private _buscar: string = '';
  public titulo: string = 'Eventos';

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
    ) { }

  public ngOnInit() {
    this.spinner.show();
    setTimeout(() => {
      /** spinner ends after 5 seconds */
      this.spinner.hide();
    }, 5000);
    this.ObterTodos();
  }

  public get buscar(): string{
    return this._buscar;
  }
  public set buscar(value: string){
    this._buscar = value;
    this.eventos = this.buscar ? this.filtrarTbEventos(this.buscar) : this._eventos
  }

  private filtrarTbEventos(filtrarPor: string){
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this._eventos.filter(
      ( evento: { tema: string; local: string }) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
                                           evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  public mostrarImg(){
    this.exibirImg = !this.exibirImg;
  }

  public ObterTodos(): void{
    this.eventoService.ObterTodosEventos().subscribe(
      (retorno: Evento[] ) =>{
        this._eventos = retorno;
        this.eventos = this._eventos;
      },
      error => console.log(error)
    )
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Evento excluído com sucesso!', 'Excluído');
  }

  decline(): void {
    this.modalRef?.hide();
  }

}
