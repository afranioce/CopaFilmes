import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { ResultComponent } from './result/result.component';
import { MatButtonModule, MatCardModule, MatToolbarModule, MatGridListModule, MatCheckboxModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';

@NgModule({
  declarations: [
    HeaderComponent,
    HomeComponent,
    ResultComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatButtonModule,
    MatCardModule,
    MatGridListModule,
    MatCheckboxModule,
    FlexLayoutModule,
  ]
})
export class ComponentsModule { }
