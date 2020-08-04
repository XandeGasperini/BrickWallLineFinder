import React, { useState } from 'react';
import WallLineConter from './components/WallLineConter';
import AlgorithmAnalyser from './components/AlgorithmAnalyser';
import { makeStyles, Button } from '@material-ui/core';

const useStyles = makeStyles((theme) => ({
  app: {
    height: "100vh",
    backgroundColor: theme.palette.background.default,
    width: "100%",
    display: 'flex',
    alignItems: 'center',
    flexDirection: 'column',
    justifyContent: "space-evenly"
  },
}))

export default function App() {
  const [page, setPage] = useState(true)
  const classes = useStyles()

  return (
    <div className={classes.app}>
      <Button variant="outlined" color="primary" onClick={() => { setPage(!page) }}>Mudar operação</Button>
      {
        page ?
          <WallLineConter /> :
          <AlgorithmAnalyser />
      }
    </div>
  );
}
