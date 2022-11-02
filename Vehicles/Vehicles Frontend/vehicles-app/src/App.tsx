import React, { useEffect, useState } from 'react';
import './App.css';
import DataTable from './Components/DataTable';
import ModalForm from './Components/ModalForm';

function App() {
  const [vehicleMakes, setVehicleMakes] = useState<any>([]);
  
  function getVehicleMakes() {
    fetch('https://localhost:44370/api/VehicleMakes/?searchString=&SortBy=ID&SortOrder=ASC')
    .then(response => response.json())
    .then(items => setVehicleMakes(items))
    
  }

  function addItemToState(item: any): void {
    setVehicleMakes(vehicleMakes.push(item))
  }

  useEffect(() => {
    if (vehicleMakes.length === 0)
    {
      getVehicleMakes();
    }
    console.log(vehicleMakes);
  }, [vehicleMakes]);


  
  return (
      <div>vehicleMakes
        <DataTable items={vehicleMakes} /> 
      
        <ModalForm item={null} buttonLabel="Add Item" addItemToState={addItemToState}/>
      </div>
  )
}


export default App;
