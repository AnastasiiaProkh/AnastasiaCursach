using System;
using System.Collections.Generic;
using AnastasiaDBCursach.Models;
using Microsoft.EntityFrameworkCore;

namespace AnastasiaDBCursach.Context;

public partial class ПрохорчукКасаКонцертноРозважальнихЗаходівContext : DbContext
{
    public ПрохорчукКасаКонцертноРозважальнихЗаходівContext()
    {
    }

    public ПрохорчукКасаКонцертноРозважальнихЗаходівContext(DbContextOptions<ПрохорчукКасаКонцертноРозважальнихЗаходівContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TableAdvertisingAgency> TableAdvertisingAgencies { get; set; }

    public virtual DbSet<TableEvent> TableEvents { get; set; }

    public virtual DbSet<TableEventType> TableEventTypes { get; set; }

    public virtual DbSet<TableGiftTicket> TableGiftTickets { get; set; }

    public virtual DbSet<TableInvitation> TableInvitations { get; set; }

    public virtual DbSet<TablePosition> TablePositions { get; set; }

    public virtual DbSet<TableRefund> TableRefunds { get; set; }

    public virtual DbSet<TableRegularCustomer> TableRegularCustomers { get; set; }

    public virtual DbSet<TableRescheduledEvent> TableRescheduledEvents { get; set; }

    public virtual DbSet<TableSponsor> TableSponsors { get; set; }

    public virtual DbSet<TableStaff> TableStaffs { get; set; }

    public virtual DbSet<TableTicket> TableTickets { get; set; }

    public virtual DbSet<TableTicketType> TableTicketTypes { get; set; }

    public virtual DbSet<VEventFee> VEventFees { get; set; }

    public virtual DbSet<VGiftTicket> VGiftTickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Прохорчук Каса концертно-розважальних заходів;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TableAdvertisingAgency>(entity =>
        {
            entity.HasKey(e => e.AgencyId);

            entity.ToTable("Table_Advertising_Agencies");

            entity.Property(e => e.AgencyId).HasColumnName("AgencyID");
            entity.Property(e => e.Aaddress)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnType("ntext")
                .HasColumnName("AAddress");
            entity.Property(e => e.AbankAccountNumber)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("ABankAccountNumber");
            entity.Property(e => e.AdateOfIssue)
                .HasColumnType("date")
                .HasColumnName("ADateOfIssue");
            entity.Property(e => e.Aname)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("AName");
            entity.Property(e => e.EventId).HasColumnName("EventID");

            entity.HasOne(d => d.Event).WithMany(p => p.TableAdvertisingAgencies)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK_Table_Advertising_Agencies_Table_Events");
        });

        modelBuilder.Entity<TableEvent>(entity =>
        {
            entity.ToTable("Table_Events");

            entity.HasIndex(e => e.Etype, "NCLIX_EType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Edate)
                .HasColumnType("date")
                .HasColumnName("EDate");
            entity.Property(e => e.Ename)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("EName");
            entity.Property(e => e.Etime).HasColumnName("ETime");
            entity.Property(e => e.Etype).HasColumnName("EType");
            entity.Property(e => e.SponsorId).HasColumnName("SponsorID");

            entity.HasOne(d => d.EtypeNavigation).WithMany(p => p.TableEvents)
                .HasForeignKey(d => d.Etype)
                .HasConstraintName("FK_Table_Events_Table_EventType");

            entity.HasOne(d => d.Sponsor).WithMany(p => p.TableEvents)
                .HasForeignKey(d => d.SponsorId)
                .HasConstraintName("FK_Table_Events_Table_Sponsors");
        });

        modelBuilder.Entity<TableEventType>(entity =>
        {
            entity.ToTable("Table_EventType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Etype)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("EType");
        });

        modelBuilder.Entity<TableGiftTicket>(entity =>
        {
            entity.HasKey(e => e.GiftTicketId);

            entity.ToTable("Table_GiftTickets");

            entity.Property(e => e.GiftTicketId).HasColumnName("GiftTicketID");
            entity.Property(e => e.TdateOfPurchase)
                .HasColumnType("date")
                .HasColumnName("TDateOfPurchase");
            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.Tprice)
                .HasColumnType("smallmoney")
                .HasColumnName("TPrice");

            entity.HasOne(d => d.Ticket).WithMany(p => p.TableGiftTickets)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK_Table_GiftTickets_Table_Tickets");
        });

        modelBuilder.Entity<TableInvitation>(entity =>
        {
            entity.ToTable("Table_Invitations");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.IbankAccountNumber)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnType("ntext")
                .HasColumnName("IBankAccountNumber");
            entity.Property(e => e.Icontacts)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnType("ntext")
                .HasColumnName("IContacts");
            entity.Property(e => e.Ifee).HasColumnName("IFee");
            entity.Property(e => e.Iname)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("IName");
            entity.Property(e => e.Irider)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("IRider");
            entity.Property(e => e.Istatus)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("IStatus");

            entity.HasOne(d => d.Event).WithMany(p => p.TableInvitations)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK_Table_Invitations_Table_Events");
        });

        modelBuilder.Entity<TablePosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table_Po__3214EC27CFA78B94");

            entity.ToTable("Table_Positions");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<TableRefund>(entity =>
        {
            entity.ToTable("Table_Refunds");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Rstatus)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("RStatus");
            entity.Property(e => e.TicketId).HasColumnName("TicketID");

            entity.HasOne(d => d.Ticket).WithMany(p => p.TableRefunds)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK_Table_Refunds_Table_Tickets");
        });

        modelBuilder.Entity<TableRegularCustomer>(entity =>
        {
            entity.ToTable("Table_Regular_Customers");

            entity.HasIndex(e => e.Rcname, "NCLIX_CustomerName");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RcbirthDate)
                .HasColumnType("date")
                .HasColumnName("RCBirthDate");
            entity.Property(e => e.Rccontacts)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnType("ntext")
                .HasColumnName("RCContacts");
            entity.Property(e => e.RcdateOfIssue)
                .HasColumnType("date")
                .HasColumnName("RCDateOfIssue");
            entity.Property(e => e.Rcname)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("RCName");
        });

        modelBuilder.Entity<TableRescheduledEvent>(entity =>
        {
            entity.ToTable("Table_Rescheduled_Events");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.NewDate).HasColumnType("date");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .UseCollation("Latin1_General_CI_AS");

            entity.HasOne(d => d.Event).WithMany(p => p.TableRescheduledEvents)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK_Table_Rescheduled_Events_Table_Events");
        });

        modelBuilder.Entity<TableSponsor>(entity =>
        {
            entity.ToTable("Table_Sponsors");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.SbankAccountNumber)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("SBankAccountNumber");
            entity.Property(e => e.Scontacts)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("SContacts");
            entity.Property(e => e.SdateOfIssue)
                .HasColumnType("date")
                .HasColumnName("SDateOfIssue");
            entity.Property(e => e.SgeneralManagerName)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("SGeneralManagerName");
            entity.Property(e => e.SponsorName)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<TableStaff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Table_Marketers");

            entity.ToTable("Table_Staff");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PositionId).HasColumnName("PositionID");
            entity.Property(e => e.StBankAccountNumber)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.StBirthDate).HasColumnType("date");
            entity.Property(e => e.StComm).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.StContacts)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnType("ntext");
            entity.Property(e => e.StName)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS");

            entity.HasOne(d => d.Position).WithMany(p => p.TableStaffs)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Table_Sta__Posit__65370702");
        });

        modelBuilder.Entity<TableTicket>(entity =>
        {
            entity.ToTable("Table_Tickets");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Etype).HasColumnName("EType");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.RcustomerId).HasColumnName("RCustomerID");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.TdateOfPurchase)
                .HasColumnType("date")
                .HasColumnName("TDateOfPurchase");
            entity.Property(e => e.Tprice)
                .HasColumnType("smallmoney")
                .HasColumnName("TPrice");
            entity.Property(e => e.Trow).HasColumnName("TRow");
            entity.Property(e => e.Tseat).HasColumnName("TSeat");
            entity.Property(e => e.Tsector)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("TSector");
            entity.Property(e => e.Ttype).HasColumnName("TType");

            entity.HasOne(d => d.EtypeNavigation).WithMany(p => p.TableTickets)
                .HasForeignKey(d => d.Etype)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_Tickets_Table_EventType");

            entity.HasOne(d => d.Event).WithMany(p => p.TableTickets)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_Tickets_Table_Events");

            entity.HasOne(d => d.Rcustomer).WithMany(p => p.TableTickets)
                .HasForeignKey(d => d.RcustomerId)
                .HasConstraintName("FK_Table_Tickets_Table_Regular_Customers");

            entity.HasOne(d => d.Staff).WithMany(p => p.TableTickets)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK_Table_Tickets_Table_Staff");

            entity.HasOne(d => d.TtypeNavigation).WithMany(p => p.TableTickets)
                .HasForeignKey(d => d.Ttype)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_Tickets_Table_TicketType");
        });

        modelBuilder.Entity<TableTicketType>(entity =>
        {
            entity.ToTable("Table_TicketType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ttype)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("TType");
        });

        modelBuilder.Entity<VEventFee>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vEventFees");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<VGiftTicket>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vGiftTickets");

            entity.Property(e => e.Customer)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.Price).HasColumnType("smallmoney");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
