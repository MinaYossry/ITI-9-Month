var par;
onload = function () {
     par = document.getElementById("PAR");
}

function ChangeFont(font)
{
    par.style.fontFamily = font;
}

function ChangeAlign(loc)
{
    par.style.textAlign = loc;
}

function ChangeHeight(height)
{
    par.style.lineHeight = height;   
}

function ChangeLSpace(spacing)
{
    par.style.letterSpacing = spacing;
}

function ChangeIndent(indent)
{
    par.style.textIndent = indent;
}

function ChangeTransform(trans)
{
    par.style.textTransform = trans;
}

function ChangeDecorate(decor)
{
    par.style.textDecoration = decor;
}

function ChangeBorder(border)
{
    par.style.borderStyle = border;
}

function ChangeBorderColor(color)
{
    par.style.borderColor = color;
}