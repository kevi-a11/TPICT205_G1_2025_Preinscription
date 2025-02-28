document.addEventListener("DOMContentLoaded", function () {
    console.log("Animations.js chargé et exécuté !");

    const body = document.body;
    const maxShapes = 8; // Nombre maximum de formes
    let shapes = [];

    // Fonction pour créer une forme (cercle ou carré)
    function createShape(shapeType) {
        if (shapes.length >= maxShapes) {
            let oldShape = shapes.shift();
            oldShape.remove(); // Supprime les anciens éléments
        }

        const shape = document.createElement("div");
        shape.classList.add(shapeType);

        // Récupérer la couleur de fond du body
        const backgroundColor = getComputedStyle(body).backgroundColor;

        // Position et taille aléatoire
        const size = Math.random() * 40 + 20; // Entre 20px et 60px
        shape.style.width = `${size}px`;
        shape.style.height = `${size}px`;
        shape.style.position = "absolute";
        shape.style.top = `${Math.random() * window.innerHeight}px`;
        shape.style.left = `${Math.random() * window.innerWidth}px`;
        shape.style.opacity = "0.8";
        shape.style.zIndex = "999";

        if (shapeType === "circle") {
            shape.style.borderRadius = "50%";
            shape.style.backgroundColor = backgroundColor; // Même couleur que le fond de la page
            shape.style.border = "2px solid white"; // Bordure blanche
        } else if (shapeType === "square") {
            shape.style.backgroundColor = backgroundColor; // Même couleur que le fond de la page
            shape.style.border = "2px solid white"; // Bordure blanche
        }

        body.appendChild(shape);
        shapes.push(shape);

        // Animation
        let moveY = Math.random() * 2 + 1; // Vitesse aléatoire
        function animate() {
            let topPos = parseFloat(shape.style.top);
            shape.style.top = `${topPos + moveY}px`;
            if (topPos > window.innerHeight) {
                shape.style.top = `-50px`;
            }
            requestAnimationFrame(animate);
        }
        animate();
    }

    // Ajouter 5 cercles et 5 carrés au départ
    for (let i = 0; i < maxShapes / 2; i++) {
        createShape("circle");
        createShape("square");
    }

    // Ajouter des formes progressivement, en alternant entre cercle et carré
    setInterval(() => {
        if (shapes.length < maxShapes) {
            createShape("circle");
            createShape("square");
        }
    }, 2000);
});
