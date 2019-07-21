import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.scss']
})
export class ResultComponent implements OnInit {
  title: string = "Resultado Final";
  description: string = "Veja o Resultado final do campeonato de filmes de forma simples e rápida.";

  constructor() { }

  ngOnInit() {
  }

}
