import '../Styles/DataTable.css';
import ModalForm from './ModalForm';
import {Button} from 'reactstrap';

function DataTable(props: { items: any[]; updateState?(vehicle: any): void; deleteItemFromState?(id: any): void }) {

    function deleteItem(id: any) {
        let confirmDelete = window.confirm('Delete item forever?');
        let fetchString = 'https://localhost:44370/api/VehicleMakes/'
        fetchString = fetchString.concat(id)
        if (confirmDelete){
            fetch(fetchString, {
                method: 'delete',
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            .then(response => response.json())
            .then((item: any) => {
                props.deleteItemFromState?.(item.ID)
            })
        }
    }

    const items: any = props.items.map(item => {
        return(
            <tr key={item.ID}>
                <td>{item.ID}</td>
                <td>{item.Name}</td>
                <td>{item.Abbreviation}</td>
                <td>
                    <ModalForm buttonLabel="Edit" item={item} updateState={props.updateState} />
                    <Button color='danger' onClick={() => deleteItem(item.ID)}>Delete</Button>
                </td>
            </tr>
    )})
    

    return (
        <div>
            <table style={{border: "1px solid black"}}>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Abbreviation</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {items}
            </tbody>
            </table>
        </div>
    )
}


export default DataTable;