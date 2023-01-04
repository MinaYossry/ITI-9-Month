function formatTime(time) {
    time = Math.round(time);

    var minutes = Math.trunc(time / 60);
    var seconds = time % 60;

    minutes = minutes.toLocaleString('en-US', {
        minimumIntegerDigits: 2
    })
    seconds = seconds.toLocaleString('en-US', {
        minimumIntegerDigits: 2
    })

    return `${minutes}:${seconds}`;
}

onload = function () {
    var video = document.getElementById("video");
    document.getElementById("totalTime").innerText = formatTime(video.duration);

    video.addEventListener("timeupdate", function () {
        document.getElementById("currentTime").innerText = formatTime(video.currentTime);
        document.getElementById("rangeSlider").value = (video.currentTime / video.duration) * 100;
    })

    document.getElementById("rangeSlider").addEventListener("input", function () {
        video.currentTime = (this.value / 100) * video.duration;
    })

    document.getElementById("play").addEventListener("click", function () {
        video.play();
    })

    document.getElementById("stop").addEventListener("click", function () {
        video.pause();
    })

    document.getElementById("fastBack").addEventListener("click", function () {
        video.currentTime = 0;
    })

    document.getElementById("back").addEventListener("click", function () {
        video.currentTime -= 5;
    })

    document.getElementById("forward").addEventListener("click", function () {
        video.currentTime += 5;
    })

    document.getElementById("fastForward").addEventListener("click", function () {
        video.currentTime = video.duration;
    })

    document.getElementById("volume").addEventListener("input", function () {
        video.volume = this.value / 100;
    })

    document.getElementById("mute").addEventListener("click", function () {
        if (video.muted) {
            this.innerText = "Mute";
        } else {
            this.innerText = "Unmute";
        }
        video.muted = !video.muted;
    })

    document.getElementById("speed").addEventListener("input", function () {
        video.playbackRate = this.value / 100;
    })
}