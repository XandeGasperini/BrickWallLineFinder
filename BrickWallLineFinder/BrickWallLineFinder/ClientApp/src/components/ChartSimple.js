import React, { useState, useEffect } from 'react';
import { Line } from 'react-chartjs-2'
import { useTheme } from '@material-ui/core';

export default function ChartSimple(props) {
    const theme = useTheme()
    const [chartData, setChartData] = useState({
        labels: [],
        datasets: [
            {
                data:  []
            }
        ]
    })

    const setChart = () => {
        setChartData({
            labels: props.chartData.labels,
            datasets: [
                {
                    label: "Tempo Execução",
                    data: props.chartData.data,
                    borderColor: "rgba(25,180,255,0.8)",
                    backgroundColor: "rgba(25,180,255,0.25)",
                    clip: { left: 0, top: 0, right: 0, bottom: 0 },
                    pointBackgroundColor: "rgba(0,0,0,0)",
                    pointBorderColor: "rgba(0,0,0,0)"
                }
            ]
        })
    }

    useEffect(() => {
        if (props.chartData.data != undefined) {
            setChart();
        }
    }, [props.chartData])


    return (
        <Line data={chartData} options={
            {
                responsive: true,
                maintainAspectRatio: false,
                layout: {
                    padding: {
                        left: 0,
                        right: 0,
                        top: 0,
                        bottom: 0
                    },
                }
            }} />
    );
}