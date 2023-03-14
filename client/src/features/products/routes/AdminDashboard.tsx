import { DeleteIcon } from "@chakra-ui/icons";
import {
  Button,
  Flex,
  IconButton,
  Input,
  InputGroup,
  InputRightElement,
  Spinner,
} from "@chakra-ui/react";
import { useMemo, useState } from "react";
import DataTable from "react-data-table-component";

import { Head } from "@/components/Head";

import { useDeleteProduct } from "../api/deleteProduct";
import { useDashboard } from "../api/getDashboard";

import type { DashboardEntryDto } from "../types";
import type { TableColumn } from "react-data-table-component";

const customStatusCell = (row: DashboardEntryDto) => {
  let status = "";

  if (row.status === 0) {
    status = "Available";
  } else if (row.status === 1) {
    status = "Unavailable";
  } else {
    status = "Out of stock";
  }

  return <span>{status}</span>;
};

const renderActionCell = (row: DashboardEntryDto) => {
  const deleteProductMutation = useDeleteProduct({});

  return (
    <Flex>
      <IconButton
        colorScheme="red"
        variant="outline"
        aria-label="Delete"
        icon={<DeleteIcon />}
        onClick={e => deleteProductMutation.mutate(row.id)}
      />
    </Flex>
  );
};

const columns: TableColumn<DashboardEntryDto>[] = [
  {
    name: "Name",
    selector: (row) => row.name,
    sortable: true,
  },
  {
    name: "Price",
    selector: (row) => row.price,
    sortable: true,
    format: (row) =>
      row.price.toLocaleString("pt-br", { style: "currency", currency: "BRL" }),
  },
  {
    name: "Stock Qty.",
    selector: (row) => row.quantityInStock,
  },
  {
    name: "Status",
    center: true,
    selector: (row) => row.status,
    cell: customStatusCell,
    conditionalCellStyles: [
      {
        when: (row) => row.status === 0,
        style: {
          backgroundColor: "rgba(63, 195, 128, 0.9)",
          color: "white",
        },
      },
      {
        when: (row) => row.status === 1,
        style: {
          backgroundColor: "rgba(255, 25, 25, 0.9)",
          color: "white",
        },
      },
      {
        when: (row) => row.status === 2,
        style: {
          backgroundColor: "rgba(248, 148, 6, 0.9)",
          color: "white",
        },
      },
    ],
  },
  {
    name: "Actions",
    center: true,
    cell: renderActionCell,
  },
];

export function AdminDashboard() {
  const { data, isFetchingNextPage, fetchNextPage } = useDashboard({
    pageNumber: 1,
  });

  const entries = data?.pages.flatMap((page) => page.items);

  const totalRows = data?.pages?.[0].totalCount;

  const [filterText, setFilterText] = useState("");
  const [resetPaginationToggle, setResetPaginationToggle] = useState(false);
  const filteredItems = entries?.filter(
    (item) =>
      item.name && item.name.toLowerCase().includes(filterText.toLowerCase()),
  );

  const subHeaderComponentMemo = useMemo(() => {
    const handleClear = () => {
      if (filterText) {
        setResetPaginationToggle(!resetPaginationToggle);
        setFilterText("");
      }
    };

    return (
      <InputGroup width="15rem">
        <Input
          onChange={(e) => setFilterText(e.target.value)}
          value={filterText}
          width="15rem"
          placeholder="Filter By Name"
        />
        <InputRightElement>
          <Button colorScheme="blue" onClick={handleClear} borderLeftRadius={0}>
            x
          </Button>
        </InputRightElement>
      </InputGroup>
    );
  }, [filterText, resetPaginationToggle]);

  const progressComponent = (
    <Flex width="full" justify="center" justifyItems="center" p={6}>
      <Spinner size="xl" color="blue" />
    </Flex>
  );

  return (
    <>
      <Head title="Admin Dashboard" />
      <DataTable
        columns={columns}
        data={filteredItems || entries || []}
        progressPending={isFetchingNextPage}
        progressComponent={progressComponent}
        pagination
        paginationServer
        paginationTotalRows={totalRows}
        paginationRowsPerPageOptions={[10, 20, 30]}
        onChangePage={() => fetchNextPage()}
        subHeader
        subHeaderComponent={subHeaderComponentMemo}
        persistTableHead
      />
    </>
  );
}
