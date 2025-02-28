function downloadPdf(pdfUrl) {
    const link = document.createElement('a');
    link.href = pdfUrl;
    link.download = 'Preinscription.pdf';
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

