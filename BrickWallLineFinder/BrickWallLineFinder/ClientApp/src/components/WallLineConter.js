import React, { useState } from 'react';

import { makeStyles, Paper, TextField, Button, Typography } from '@material-ui/core';

import { postBrickWall } from "../modules/ApiModule"

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
  }
})

function dataToObj(data) {
  var obj = { Rows: [] }

  data.forEach(element => {
    obj.Rows.push({ Bricks: element })
  });

  return obj
}

export default function WallLineConter() {
  const [data, setData] = useState({})
  const [line, setLine] = useState({})
  const classes = useStyles()

  async function getBrickWallLine() {
    console.log("ops")
    try {
      const obj = dataToObj(JSON.parse(data));

      const response = await postBrickWall(obj)

      setLine(response)
    } catch (err) {
      console.log(err)
      alert("Erro ao obter linha, cheque objeto e tente novamente")
    }
  }

  return (
    <Paper elevation={4} className={classes.paper}>
      <Typography variant="h5">Contador Linha</Typography>
      <Typography variant="subtitle1"> Para obter a menor quantidade de tijolos cortados, insira parede abaixo</Typography>
      <Typography variant="subtitle2"> *ex: [[1,1],[2]]</Typography>
      <TextField
        className={classes.field}
        label="Parede de Tijolos"
        variant="outlined"
        onChange={(event) => { setData(event.target.value) }}
      />
      <Button className={classes.button} variant="outlined" color="primary" onClick={getBrickWallLine}>Obter linha</Button>
      {line.hits ?
        <div>
          <Typography> resultado: {line.hits}</Typography>
          <Typography> tempo(millis): {line.tick}</Typography>
        </div>
        :
        <div />
      }
    </Paper>
  );
}