import { useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody } from 'reactstrap';
import AddEditForm from './AddEditForm';

function ModalForm(props: {
    buttonLabel?: any; item?: any; addItemToState?: (item: any) => void;
}) {
    
    const [modal, setModal] = useState(false)

    function toggle() {
        setModal(!modal)
    }

    const closeButton = <button className="close" onClick={toggle}>&times;</button>
    const label = props.buttonLabel

    let button: any = null
    let title = ''

    if (label === 'Edit'){
        button = <Button
                    color="warning"
                    onClick={toggle}
                    style={{float: "left", marginRight:"10px"}}>{label}
                </Button>
        title = 'Edit item'
    }
    else {
        button = <Button
                    color="success"
                    onClick={toggle}
                    style={{float: "left", marginRight:"10px"}}>{label}
                </Button>
        title = 'Add New Item'
    }

    return (
            <div>
                {button}
                <Modal isOpen={modal} toggle={toggle} /*className={props.className}*/ >
                    <ModalHeader toggle={toggle} close={closeButton}>{title}</ModalHeader>
                    <ModalBody>
                        <AddEditForm addItemToState={props.addItemToState} toggle={toggle} item={props.item}/>
                    </ModalBody>
                </Modal>
            </div>
    )
}


export default ModalForm;