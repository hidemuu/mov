window.renderChart = (canvasId, chartData) => {
    const ctx = document.getElementById(canvasId).getContext('2d');
    new Chart(ctx, {
        type: 'line',
        data: {
            labels: chartData.labels,
            datasets: [
                {
                    label: '理想進捗',
                    data: chartData.idealBurndown,
                    borderColor: 'rgba(75, 192, 192, 1)',
                    borderWidth: 2,
                    fill: false
                },
                {
                    label: '実績進捗',
                    data: chartData.actualBurndown,
                    borderColor: 'rgba(255, 99, 132, 1)',
                    borderWidth: 2,
                    fill: false
                }
            ]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    display: true
                }
            },
            scales: {
                x: {
                    title: {
                        display: true,
                        text: '週'
                    }
                },
                y: {
                    title: {
                        display: true,
                        text: '残工数'
                    },
                    beginAtZero: true
                }
            }
        }
    });
};
