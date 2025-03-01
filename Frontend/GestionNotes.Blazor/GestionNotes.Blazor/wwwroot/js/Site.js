﻿window.downloadFile = (fileName, base64Content) => {
    const link = document.createElement('a');
    link.href = 'data:application/pdf;base64,' + base64Content;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};
