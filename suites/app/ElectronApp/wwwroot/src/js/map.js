let map;

function initializeMap() {
    map = L.map('map').setView([1.3521, 103.8198], 13); // シンガポールの座標

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    // サンプルのマーカー
    L.marker([1.3521, 103.8198]).addTo(map)
        .bindPopup('Singapore Center')
        .openPopup();

    // 地図上のクリックイベントを監視
    map.on('click', function (e) {
        // Blazorアプリケーションにクリックイベントを通知
        DotNet.invokeMethodAsync('TravelPlannerApp.Shared', 'OnMapClick', e.latlng.lat, e.latlng.lng)
            .then(() => console.log(`Clicked at ${e.latlng.lat}, ${e.latlng.lng}`))
            .catch(err => console.error(err));
    });
}

function updateMap(lat, lng, zoom) {
    map.setView([lat, lng], zoom);
}