import '../Styles/DataTable.css'
import ModalForm from './ModalForm';

function DataTable(props: { items: any[]; }) {

    const items: any = props.items.map(item => {
        return(
            <tr key={item.ID}>
                <td>{item.ID}</td>
                <td>{item.Name}</td>
                <td>{item.Abbreviation}</td>
                <td>
                    <ModalForm buttonLabel="Edit" item={item}/*updateState={this.props.updateState}*/ />
                    <button>Delete</button>
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