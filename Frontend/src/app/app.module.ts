import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { InvestmentPlanningComponent } from './components/investment-planning/investment-planning.component';

const routes: Routes = [
  { path: '', component: InvestmentPlanningComponent },
  // other routes if needed
];

@NgModule({
  declarations: [
    AppComponent,
    InvestmentPlanningComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
