type TStaff = {
  id: number;

  stName?: string;

  stBirthDate: string;

  stComm: Number;

  stContacts?: string;

  stBankAccountNumber?: string;

  positionId?: number;
};

type TPosition = {
  id: number;
  name: string;
};

type TTicketType = {
  id: number;
  ttype: string;
};

type TEventType = {
  id: number;
  etype: string;
};

type TAdvertisingAgencies = {
  agencyId: number;
  aname: string;
  aaddress: string;
  abankAccountNumber: string;
  adateOfIssue: string;
  eventId: number;
};

type TEvent = {
  id: number;
  ename: string;
  etype: number;
  edate: string;
};

type TGiftTicket = {
  giftTicketId: number;
  ticketId: number;
  tprice: number;
  tdateOfPurchase: string;
};

type TInvitations = {
  id: number;
  iname: string;
  eventId: number;
  istatus: string;
  ifee: number;
  irider: string;
  icontacts: string;
  ibankAccountNumber: string;
};

type TRefund = {
  id: number;
  ticketId: number;
  rstatus: string;
};

type TRegularCustomer = {
  id: number;
  rcname: string;
  rcbirthDate: string;
  rcdateOfIssue: string;
  rccontacts: string;
};

type TRescheduled = {
  id: number;
  eventId: number;
  status: string;
};

type TSponsors = {
  id: 0;
  sponsorName: string;
  sdateOfIssue: string;
  sgeneralManagerName: string;
  scontacts: string;
  sbankAccountNumber: string;
};

type TTicket = {
  id: number;
  eventId: number;
  etype: number;
  ttype: number;
  trow: number;
  tseat: number;
  tsector: string;
  tprice: number;
  rcustomerId: number;
  tdateOfPurchase: string;
  staffId: number;
};

export type {
  TStaff,
  TPosition,
  TTicketType,
  TEventType,
  TAdvertisingAgencies,
  TEvent,
  TGiftTicket,
  TInvitations,
  TRefund,
  TRegularCustomer,
  TRescheduled,
  TSponsors,
  TTicket,
};
