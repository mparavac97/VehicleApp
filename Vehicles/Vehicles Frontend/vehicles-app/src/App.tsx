import React, { useEffect, useState} from 'react';
import './App.css';
import './Styles/Pagination.css'
// @ts-ignore
import MakesDataTable from './Components/MakesDataTable.tsx';
// @ts-ignore
import MakesModalForm from './Components/MakesModalForm.tsx';
// @ts-ignore
import ModelsDataTable from './Components/ModelsDataTable.tsx';
// @ts-ignore
import ModelsModalForm from './Components/ModelsModalForm.tsx';

function App() {
  const [vehicleMakes, setVehicleMakes] = useState<any>([]);
  const [vehicleModels, setVehicleModels] = useState<any>([]);

  const [sortParams, setSortParams] = useState({sortBy: "ID", sortOrder: "ASC"})
  const [filterParam, setFilterParam] = useState("")
  const [pagerParams, setPagerParams] = useState({pageSize: 5, pageNumber: 1})
  const [totalPages, setTotalPages] = useState(2);
  const [refreshKey, setRefreshKey] = useState(0);

  function onSortByParamChange(event: any) {
    setSortParams({...sortParams, sortBy: event.target.value});
  }

  function onSortOrderParamChange(event: any) {
    setSortParams({...sortParams, sortOrder: event.target.value});
  }

  function onFilterParamChange(event: any) {
    setFilterParam(event.target.value)
  }

  function onPageSizeChange(event: any) {
    setPagerParams({...pagerParams, pageSize: event.target.value})
  }

  function onPageChange(event: any) {
    setPagerParams({...pagerParams, pageNumber: event.target.id})
  }

  let pages: number[] = [];
  for(let i=1; i <= totalPages; i++){
    pages.push(i);
  }

  const pageNumbers = pages.map(page => {
    return(
      <button key={page} id={page.toString()} onClick={onPageChange} className={pagerParams.pageNumber===page ? 'active' : 'null'}>{page}</button>
    )
  }) 

  function getVehicleMakes(): void {
    fetch(`https://localhost:44370/api/VehicleMakes/?SortBy=${sortParams.sortBy}&SortOrder=${sortParams.sortOrder}
          &PageSize=${pagerParams.pageSize}&PageNumber=${pagerParams.pageNumber}&Name=${filterParam}`,{
      headers: {
        'Content-type': 'application/json'
    },
    })
    .then(response => response.json())
    .then(items => setVehicleMakes(items))  
  }

  function getVehicleModels() {
    fetch(`https://localhost:44370/api/VehicleModels/?SortBy=${sortParams.sortBy}&SortOrder=${sortParams.sortOrder}
    &PageSize=${pagerParams.pageSize}&PageNumber=${pagerParams.pageNumber}`,{
      headers: {
        'Content-type': 'application/json'
    },
    })
    .then(response => response.json())
    .then(items => setVehicleModels(items)) 
  }

  function addMakeToState(vehicle: any): void {
    setVehicleMakes((prevState: any) => [...prevState, vehicle])
    setRefreshKey(oldKey => oldKey + 1)
  }

  function updateMakeState(vehicle: any): void {
    const vehicleIndex = vehicleMakes.findIndex((data: any) => data.id === vehicle.ID);
    const newArray = [
      ...vehicleMakes.slice(0, vehicleIndex),
      vehicle,
      ...vehicleMakes.slice(vehicleIndex + 1)
    ]
    setVehicleMakes(newArray);
    setRefreshKey(oldKey => oldKey + 1)
  }

  function deleteMakeFromState(vehicle: any) {
    const updatedItems = vehicleMakes.filter((item: { id: any; }) => item.id !== vehicle.ID)
    setVehicleMakes(updatedItems)
    setRefreshKey(oldKey => oldKey + 1)
  }

  function addModelToState(vehicle: any): void {
    setVehicleModels((prevState: any) => [...prevState, vehicle])  
    setRefreshKey(oldKey => oldKey + 1)
  }

  function updateModelState(vehicle: any): void {
    const vehicleIndex = vehicleModels.findIndex((data: any) => data.id === vehicle.ID);
    const newArray = [
      ...vehicleModels.slice(0, vehicleIndex),
      vehicle,
      ...vehicleModels.slice(vehicleIndex + 1)
    ]
    setVehicleModels(newArray);
    setRefreshKey(oldKey => oldKey + 1)
  }

  function deleteModelFromState(vehicle: any) {
    const updatedItems = vehicleModels.filter((item: { id: any; }) => item.id !== vehicle.ID)
    setVehicleModels(updatedItems)
    setRefreshKey(oldKey => oldKey + 1)
  }

  useEffect(() => {
    
      getVehicleMakes();
      getVehicleModels();
    
    console.log(vehicleMakes, vehicleModels);
  }, [sortParams, filterParam, pagerParams, refreshKey]);


  
  return (
      <div><h2>Vehicle Makes</h2>
        Sort by: <select id='sortBy' onChange={onSortByParamChange}>
          <option value='ID'>ID</option>
          <option value='Name'>Name</option>
          <option value='Abbreviation'>Abbreviation</option>
        </select>
        Sort order: <select id='sortOrder' onChange={onSortOrderParamChange}>
          <option value='ASC'>ASC</option>
          <option value='DESC'>DESC</option>
        </select> <br />
        Filter by name: <input type="text" id='nameFilter' onChange={onFilterParamChange}></input> <br/>
        Items per page: <input type="number" id='pageSize' onChange={onPageSizeChange} value={pagerParams.pageSize}></input> <br/>
        <MakesModalForm item={null} buttonLabel="Add New Item" addItemToState={addMakeToState}/> <br/> <br/>
        <MakesDataTable items={vehicleMakes} updateState={updateMakeState} deleteItemFromState={deleteMakeFromState}/> 
        
        {pageNumbers}

        <br/>
        <h2>Vehicle Models</h2>
        <ModelsModalForm item={null} buttonLabel="Add New Item" addItemToState={addModelToState}/> <br/> <br/>
        <ModelsDataTable items={vehicleModels} updateState={updateModelState} deleteItemFromState={deleteModelFromState} />
        <br/> <br/>
      </div>
  )
}

export default App;
