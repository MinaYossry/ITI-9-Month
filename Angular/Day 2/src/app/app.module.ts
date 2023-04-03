import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BindedInputComponent } from './Components/binded-input/binded-input.component';
import { SliderComponent } from './Components/slider/slider.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [AppComponent, BindedInputComponent, SliderComponent],
  imports: [BrowserModule, FormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
