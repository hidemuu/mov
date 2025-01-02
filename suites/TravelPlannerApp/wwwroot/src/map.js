function initializeMap() {
    var map = L.map('map').setView([1.3521, 103.8198], 13); // シンガポールの座標

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    // サンプルのマーカー
    L.marker([1.3521, 103.8198]).addTo(map)
        .bindPopup('Singapore Center')
        .openPopup();
}
