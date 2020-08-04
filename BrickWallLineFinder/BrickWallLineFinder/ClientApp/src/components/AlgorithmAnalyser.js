import React, { useState, useEffect } from 'react';

import ChartSimple from './ChartSimple'

import { makeStyles, Paper, TextField, Button, Grid, Typography } from '@material-ui/core';

import { getAnalysis } from "../modules/ApiModule"

const useStyles = makeStyles({
    paper: {
        height: "60%",
        minHeight: "300px",
        width: "30%",
        minWidth: "300px",
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: "space-evenly"
    },
    group: {
        width: "100%",
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: "space-evenly"
    },
    field: {
        width: "80%"
    },
    button: {
        width: "30%"
    },
    imagem: {
        width: "50%",
        height: "auto"
    },
    chartPaper: {
        height: "20%",
        width: "30%"
    }
})

export default function AlgorithmAnalyser() {
    const [bricks, setBricks] = useState({})
    const [rows, setRows] = useState({})
    const [bricksInc, setBricksInc] = useState({})
    const [rowsInc, setRowsInc] = useState({})
    const [data, setData] = useState()
    const [loading, setLoading] = useState(0)

    const classes = useStyles()

    async function getAlgorithAnalysis() {
        try {
            setLoading(1)
            const response = await getAnalysis({
                bricks: bricks,
                rows: rows,
                bricksInc: bricksInc,
                rowsInc: rowsInc
            })

            console.log(response)
            var obj = { data: response.millis, labels: [] }

            response.millis.forEach((element, index) => {
                obj.labels.push(index)
            });

            setData(obj)
            setLoading(0)
        } catch (err) {
            console.log(err)
            alert("Erro ao realizar análise")
        }
    }

    return (
        <>
            <Paper elevation={4} className={classes.paper}>
                <Typography variant="h5">Análise</Typography>
                <Typography className={classes.field} variant="subtitle1">Para obter uma análise, preencha com o numero de tijolos por linha, numero de linhas e o incremento de cada</Typography>
                <TextField
                    className={classes.field}
                    label="Max Tijolos por linha"
                    variant="outlined"
                    onChange={(event) => { setBricks(event.target.value) }}
                />
                <TextField
                    className={classes.field}
                    label="Incremento de Tijolos"
                    variant="outlined"
                    onChange={(event) => { setBricksInc(event.target.value) }}
                />
                <TextField
                    className={classes.field}
                    label="Linhas"
                    variant="outlined"
                    onChange={(event) => { setRows(event.target.value) }}
                />
                <TextField
                    className={classes.field}
                    label="Incremento de linha"
                    variant="outlined"
                    onChange={(event) => { setRowsInc(event.target.value) }}
                />
                <Button className={classes.button} variant="outlined" color="primary" onClick={getAlgorithAnalysis}>Obter análise</Button>
                {
                    loading?
                    <Typography>Esperando Servidor...</Typography>:
                    <div></div>
                }
            </Paper>
            {
                data ?
                    <Paper elevation={4} className={classes.chartPaper}>
                        <ChartSimple chartData={data} />
                    </Paper> :
                    <div />
            }
        </>
    );
}