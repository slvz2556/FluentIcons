
function ScrollToTop() {
    document.querySelector('.grid').scrollTo({ top: 0, behavior: 'smooth' });
}

function CopyText(val) {
    navigator.clipboard.writeText(val);
}


function DownloadFile(url) {
    var a = document.createElement('a');
    a.href = url;
    a.download = url.split('/').pop();
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
}


window.getNewBatch = () => {
    const el = document.querySelector('.grid');

    var sTop = el ? el.scrollTop : 0;
    var sHeight = el ? el.scrollHeight : 0;
    var cHeight = el ? el.clientHeight : 0;

    if (sTop + cHeight >= sHeight - 50)
        return true;
    else
        return false;

}
