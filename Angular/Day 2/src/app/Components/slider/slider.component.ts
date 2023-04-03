import { Component } from '@angular/core';

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.css'],
})
export class SliderComponent {
  imgNumber = 1;
  imgSrc = `assets/Images/${this.imgNumber}.png`;
  interval: any = null;
  Next() {
    this.imgNumber += this.imgNumber == 5 ? 0 : 1;
    this.imgSrc = `assets/Images/${this.imgNumber}.png`;
  }

  Prev() {
    this.imgNumber -= this.imgNumber == 1 ? 0 : 1;
    this.imgSrc = `assets/Images/${this.imgNumber}.png`;
  }

  Start() {
    this.interval = setInterval(() => {
      this.imgNumber = ++this.imgNumber % 6;
      if (this.imgNumber == 0) {
        this.imgNumber = 1;
      }
      this.imgSrc = `assets/Images/${this.imgNumber}.png`;
    }, 500);
  }

  End() {
    clearInterval(this.interval);
  }
}
