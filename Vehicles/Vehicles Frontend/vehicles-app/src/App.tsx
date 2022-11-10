import React, { useEffect, useState} from 'react';
import './App.css';
import DataTable from './Components/DataTable';
import ModalForm from './Components/ModalForm';

function App() {
  const [vehicleMakes, setVehicleMakes] = useState<any>([]);
  const [vehicleModels, setVehicleModels] = useState<any>([]);
  const [sortParams, setSortParams] = useState({sortBy: "ID", sortOrder: "DESC"})

  const [makesFetchString, setString] = useState(`https://localhost:44370/api/VehicleMakes/?SortBy=${sortParams.sortBy}&SortOrder=${sortParams.sortOrder}&PageSize=20&PageNumber=1`)

  function onParamChange(event: any) {
    setSortParams({...sortParams, sortBy: event.target.value});
    
    console.log(sortParams)
  }

  function getVehicleMakes(): void {
    fetch(makesFetchString,{
      headers: {
        'Content-type': 'application/json'
    },
    })
    .then(response => response.json())
    .then(items => setVehicleMakes(items))   
  }

  function getVehicleModels() {
    fetch('https://localhost:44370/api/VehicleModels/?SortBy=ID&SortOrder=ASC&PageSize=30&PageNumber=1',{
      headers: {
        'Content-type': 'application/json'
    },
    })
    .then(response => response.json())
    .then(items => setVehicleModels(items))   
  }

  function addItemToState(item: any): void {
    setVehicleMakes((prevState: any) => [...prevState, item])  
  }

  function updateState(vehicle: any): void {
    const vehicleIndex = vehicleMakes.findIndex((data: any) => data.id === vehicle.ID);
    const newArray = [
      ...vehicleMakes.slice(0, vehicleIndex),
      vehicle,
      ...vehicleMakes.slice(vehicleIndex + 1)
    ]
    setVehicleMakes(newArray);
  }

  function deleteItemFromState(vehicle: any) {
    const updatedItems = vehicleMakes.filter((item: { id: any; }) => item.id !== vehicle.ID)
    setVehicleMakes(updatedItems)
  }

  useEffect(() => {
    if (vehicleMakes.length === 0)
    {
      getVehicleMakes();
      getVehicleModels();
    }
    console.log(vehicleMakes, vehicleModels);
    console.log(makesFetchString)
  }, [vehicleMakes, vehicleModels, makesFetchString]);


  
  return (
      <div>Vehicle Makes <br />
        Sort by: <select id='sortBy' onChange={onParamChange}>
          <option value='ID'>ID</option>
          <option value='Name'>Name</option>
          <option value='Abbreviation'>Abbreviation</option>
        </select>
        Sort order: <select id='sortOrder'>
          <option value='ASC'>ASC</option>
          <option value='DESC'>DESC</option>
        </select>
        <button>Submit</button>
        <DataTable items={vehicleMakes} updateState={updateState} deleteItemFromState={deleteItemFromState}/> 
        Vehicle Models
        <DataTable items={vehicleModels} />
        <ModalForm item={null} buttonLabel="Add Item" addItemToState={addItemToState}/>
      </div>
  )
}


export default App;
