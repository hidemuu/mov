let chartInstances = {};

window.createChart = (canvasId, type, labels, data, name) => {
    const ctx = document.getElementById(canvasId).getContext('2d');
    // 既存のチャートが存在する場合、破棄する
    if (chartInstances[canvasId]) {
        chartInstances[canvasId].destroy();
    }
    chartInstances[canvasId] = new Chart(ctx, {
        type: type,
        data: {
            labels: labels,
            datasets: [{
                label: name,
                data: data,
                borderColor: 'rgba(75, 192, 192, 1)',
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                fill: true,
                tension: 0.4
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: { display: true }
            },
            scales: {
                x: { beginAtZero: true },
                y: { beginAtZero: true }
            }
        }
    });
};

window.toggleChartVisibility = (chartId, show) => {
    const canvas = document.getElementById(chartId);
    if (canvas) {
        canvas.style.display = show ? 'block' : 'none';
    }
};
